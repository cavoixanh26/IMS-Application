import { Component, OnDestroy, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';
import { ClassClient, ClassDto, ClassReponse, SettingClient, SettingResponse, SettingType, SubjectClient, SubjectReponse } from 'src/app/api/api-generate';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ClassModalComponent } from './class-modal/class-modal.component';
import { MessageConstants } from 'src/app/shared/constants/message.const';
import { UtilityService } from 'src/app/shared/services/utility.service';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
})
export class ClassComponent implements OnInit, OnDestroy {
  //System variables
  private ngUnsubscribe = new Subject<void>();
  public blockedPanel: boolean = false;

  public items: ClassDto[];
  public selectedItem: ClassDto;
  //Paging variables
  public page: number = 1;
  public itemsPerPage: number = 5;
  public totalCount: number;
  public keyWords: string;
  public skip: number | null;
  public take: number | null;
  public sortField: string | null;

  //Filter variables
  subjectId: number;
  settingId: number;
  subjectList: any[] = [];
  settingList: any[] = [];
  constructor(
    private classService: ClassClient,
    private subjectService: SubjectClient,
    private settingService: SettingClient,
    public dialogService: DialogService,
    private notificationService: NotificationService,
    private confirmationService: ConfirmationService,
    private utilService: UtilityService
  ) {}

  ngOnInit() {
    this.loadData();
    this.loadSettings();
    this.loadSubjects();
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  loadData(selectionId = null) {
    this.toggleBlockUI(true);

    this.classService
      .classGET(
        this.settingId,
        this.subjectId,
        this.keyWords,
        this.page,
        this.itemsPerPage,
        this.skip,
        this.take,
        this.sortField
      )
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: ClassReponse) => {
          this.items = response.classes;
          this.totalCount = response.page.toTalRecord;
          if (selectionId != null && this.items.length > 0) {
            this.selectedItem = this.items.find((x) => x.id == selectionId);
          }

          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }

  loadSubjects() {
    this.subjectService
      .subjectGET2(
        this.keyWords,
        this.page,
        this.itemsPerPage,
        this.skip,
        this.take,
        this.sortField
      )
      .subscribe((response: SubjectReponse) => {
        response.subjects.forEach((s) => {
          this.subjectList.push({
            label: s.name,
            value: s.id,
          });
        });
      });
  }

  handleDropdownChange(newValue: any, attribute: string) {
    if (newValue === null) {
      this[attribute] = undefined;
      this.loadData();
    } else {
      this.loadData();
    }
  }

  loadSettings() {
    this.settingService
      .settingGET(
        SettingType._1,
        this.keyWords,
        this.page,
        this.itemsPerPage,
        this.skip,
        this.take,
        this.sortField
      )
      .subscribe((response: SettingResponse) => {
        this.settingList = response.settings.map((setting) => ({
          label: setting.name,
          value: setting.id,
        }));
      });
  }

  showAddModal() {
    const ref = this.dialogService.open(ClassModalComponent, {
      header: 'Add Class',
      width: '70%',
    });

    ref.onClose.subscribe((isSuccess: boolean) => {
      if (isSuccess == true) {
        this.notificationService.showSuccess(MessageConstants.CREATED_OK_MSG);
        this.selectedItem = null;
        this.loadData();
      }
      if (isSuccess == false) {
        this.notificationService.showError(MessageConstants.CREATED_FALL_MSG);
      }
    });
  }

  showEditModal(id: number) {
    const ref = this.dialogService.open(ClassModalComponent, {
      data: {
        id: id,
      },
      header: 'Update class',
      width: '70%',
    });

    ref.onClose.subscribe((data: ClassDto) => {
      if (data) {
        this.notificationService.showSuccess(MessageConstants.UPDATED_OK_MSG);
        this.selectedItem = null;
        this.loadData(data.id);
      }
      if (data === null) {
        this.notificationService.showError(MessageConstants.UPDATED_FALL_MSG);
      }
    });
  }

  showDetail(classDto: ClassDto) {
    let url: string = 'detail/' + classDto.id;
    this.utilService.navigate(url);
  }

  pageChanged(event: any) {
    this.page = event.page + 1;
    this.itemsPerPage = event.rows;
    this.loadData({
      page: this.page,
      itemsPerPage: this.itemsPerPage,
    });
  }

  private toggleBlockUI(enabled: boolean) {
    if (enabled == true) {
      this.blockedPanel = true;
    } else {
      setTimeout(() => {
        this.blockedPanel = false;
      }, 1000);
    }
  }
}
