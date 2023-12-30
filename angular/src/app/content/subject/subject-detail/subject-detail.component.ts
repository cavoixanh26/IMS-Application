import { Subject, takeUntil } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AssignmentClient, AssignmentDTO, AssignmentResponse, ClassClient, ClassDto, ClassReponse, SubjectClient, SubjectReponse } from 'src/app/api/api-generate';
import { DialogService } from 'primeng/dynamicdialog';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ConfirmationService } from 'primeng/api';
import { UtilityService } from 'src/app/shared/services/utility.service';
import { MessageConstants } from 'src/app/shared/constants/message.const';
import { AssignmentDetailComponent } from './assignment-detail/assignment-detail.component';
import { SubjectDto } from '../../../api/api-generate';

@Component({
  selector: 'app-subject-detail',
  templateUrl: './subject-detail.component.html',
})
export class SubjectDetailComponent implements OnInit ,OnDestroy {
   //System variables
   private ngUnsubscribe = new Subject<void>();
   public blockedPanel: boolean = false;
   activeIndex: number = -1; // Khởi tạo activeIndex với giá trị mặc định
  subjectId;

   //Paging variables
   public page: number = 1;
   public itemsPerPage: number = 5;
   public totalCount: number;
   public keyWords: string |  null;
   public skip: number | null;
   public take: number | null;
  public sortField: string | null;
  
  public settingId: number | null;

  //Api variables
  public items: ClassDto[];
  public selectedItems: AssignmentDTO[] = [];

  public subjectDto: SubjectDto;

  constructor(private activatedRoute: ActivatedRoute,
    private subjectService: SubjectClient,
    public dialogService: DialogService,
    private assignmentService : AssignmentClient,
    private notificationService: NotificationService,
    private confirmationService: ConfirmationService,
    private classService: ClassClient,
    private router: Router,
    private utilService : UtilityService,
    ) {

  }
  ngOnInit() {

    this.subjectId = this.activatedRoute.snapshot.paramMap.get('id');
    this.getSubjectById(this.subjectId);
    this.loadClassBySubjectId(this.subjectId);
    this.loadData();
  }


  getSubjectById(id: number) {
    this.subjectService
      .subjectGET(id)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: SubjectDto) => {
          this.subjectDto = response;
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }

  loadClassBySubjectId(subjectId: number) {
    this.toggleBlockUI(true);
    this.classService.classGET(this.settingId, subjectId, this.keyWords, this.page, this.itemsPerPage, this.skip, this.take, this.sortField)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: ClassReponse) => {
          this.items = response.classes;
          this.totalCount = response.page.toTalRecord;
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        }
      });
  }

  loadData(selectionId = null) {
  //   this.toggleBlockUI(true);

  //   this.assignmentService
  //   .assignments(this.subjectId,this.keyWords, this.page, this.itemsPerPage, this.skip, this.take, this.sortField)
  //     .pipe(takeUntil(this.ngUnsubscribe))
  //     .subscribe({
  //       next: (response: AssignmentResponse) => {
  //         this.items = response.assignments;
  //         this.totalCount = response.page.toTalRecord;
  //         if (selectionId != null && this.items.length > 0) {
  //           this.selectedItems = this.items.filter(x => x.id == selectionId);
  //         }

  //         this.toggleBlockUI(false);
  //       },
  //       error: () => {
  //         this.toggleBlockUI(false);
  //       },
  //     });
  }

  showAddModal() {
    const ref = this.dialogService.open(AssignmentDetailComponent, {
      data: {
        subjectId: this.subjectId,
      },
      header: 'Add Assignment',
      width: '70%',

    });

    ref.onClose.subscribe((data: AssignmentDTO) => {
      if (data) {
        this.notificationService.showSuccess(MessageConstants.CREATED_OK_MSG);
        this.selectedItems = [];
        this.loadData();
      }
    });
  }

  showEditModal() {
    if (this.selectedItems.length == 0) {
      this.notificationService.showError(MessageConstants.NOT_CHOOSE_ANY_RECORD);
      return;
    }
    var id = this.selectedItems[0].id;
    const ref = this.dialogService.open(AssignmentDetailComponent, {
      data: {
        id: id,
      },
      header: 'Update Assignment',
      width: '70%',
    });

    ref.onClose.subscribe((data: AssignmentDTO) => {
      if (data) {
        this.notificationService.showSuccess(MessageConstants.UPDATED_OK_MSG);
        this.selectedItems = [];
        this.loadData(data.id);
      }
    });
  }

  deleteItems() {
    if (this.selectedItems.length == 0) {
      this.notificationService.showError(MessageConstants.NOT_CHOOSE_ANY_RECORD);
      return;
    }
    var ids = [];
    this.selectedItems.forEach(element => {
      ids.push(element.id);
    });
    this.confirmationService.confirm({
      message: MessageConstants.CONFIRM_DELETE_MSG,
      accept: () => {
        this.deleteItemsConfirm(ids);
      },
    });
  }

  deleteItemsConfirm(id: any) {
    this.toggleBlockUI(true);

    this.assignmentService.deleteAssignment(id).subscribe({
      next: () => {
        this.notificationService.showSuccess(MessageConstants.DELETED_OK_MSG);
        this.loadData();
        this.selectedItems = [];
        this.toggleBlockUI(false);
      },
      error: () => {
        this.toggleBlockUI(false);
      },
    });
  }
  onTabClick(index: number) {
    if (this.activeIndex === index) {
      // Nếu tab đã được chọn rồi, bỏ chọn nó
      this.activeIndex = null;
      this.selectedItems = [];
    } else {
      // Nếu tab chưa được chọn, chọn nó và cập nhật selectedItems
      this.activeIndex = index;
      this.selectedItems = [this.items[index]];
    }
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

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
}
