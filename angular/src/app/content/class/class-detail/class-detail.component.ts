import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';
import { AddStudentInClassRequest, ClassClient, ClassDto, ProjectClient, ProjectDto, ProjectReponse, StudentDto, StudentResponse, UserClient, UserDto, UserResponse } from 'src/app/api/api-generate';
import { MessageConstants } from 'src/app/shared/constants/message.const';
import { FileService } from 'src/app/shared/services/file.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { UtilityService } from 'src/app/shared/services/utility.service';

@Component({
  selector: 'app-class-detail',
  templateUrl: './class-detail.component.html',
})
export class ClassDetailComponent implements OnInit, OnDestroy {
  //System variables
  private ngUnsubscribe = new Subject<void>();
  public blockedPanel: boolean = false;

  classId;
  public detailClass: ClassDto;

  //Paging variables
  public page: number = 1;
  public itemsPerPage: number = 5;
  public totalCount: number;
  public keyWords: string | null;
  public skip: number | null;
  public take: number | null;
  public sortField: string | null;

  //Api variables
  public items: StudentDto[];
  public selectedItems: StudentDto[] = [];

  visible: boolean = false;
  studentList: any[] = [];

  public itemsProject: ProjectDto[];
  public selectedItemsProject: ProjectDto[] = [];

  public selectedStudents: any[] = [];

  constructor(
    private activatedRoute: ActivatedRoute,
    public dialogService: DialogService,
    private userService: UserClient,
    private classService: ClassClient,
    private notificationService: NotificationService,
    private confirmationService: ConfirmationService,
    private router: Router,
    private utilService: UtilityService,
    private projectService: ProjectClient,
    private fileService: FileService
  ) {}

  ngOnInit() {
    this.classId = this.activatedRoute.snapshot.paramMap.get('id');
    this.loadDetailClass(this.classId);
    this.loadStudentList();
    this.loadDataProjects();
    this.loadStudents();
  }

  loadDetailClass(id: number) {
    this.classService
      .classGET2(id)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe((response: ClassDto) => (this.detailClass = response));
  }

  loadStudentList(selectionId = null) {
    this.toggleBlockUI(true);
    this.classService
      .studentsList(
        this.classId,
        this.keyWords,
        this.page,
        this.itemsPerPage,
        this.skip,
        this.take,
        this.sortField
      )
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: StudentResponse) => {
          this.items = response.students;
          this.items.forEach(
            async (x) => (x.avatar = await this.GetFileFromFirebase(x.avatar))
          );

          this.totalCount = response.page.toTalRecord;
          if (selectionId != null && this.items.length > 0) {
            this.selectedItems = this.items.filter((x) => x.id == selectionId);
          }
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }

  loadDataProjects(selectionId = null) {
    //   this.toggleBlockUI(true);
    //   this.projectService
    //   .projectGET(this.classId,this.keyWords, this.page, this.itemsPerPage, this.skip, this.take, this.sortField)
    //     .pipe(takeUntil(this.ngUnsubscribe))
    //     .subscribe({
    //       next: (response: ProjectReponse) => {
    //         this.itemsProject = response.projects;
    //         if (selectionId != null && this.items.length > 0) {
    //           this.selectedItemsProject = this.itemsProject.filter(x => x.id == selectionId);
    //         }
    //         this.toggleBlockUI(false);
    //       },
    //       error: () => {
    //         this.toggleBlockUI(false);
    //       },
    //     });
  }

  loadStudents() {
    this.userService
      .users(
        undefined,
        undefined,
        undefined,
        undefined,
        undefined,
        undefined,
        undefined
      )
      .subscribe((response: UserResponse) => {
        response.users.forEach((s) => {
          this.studentList.push({
            label: s.fullName,
            value: s.id,
          });
        });
      });
  }

  public async GetFileFromFirebase(fileName: string) {
    if (fileName === null) {
      return 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRuH4tyG12O2rHbqYAnze8XPhJhJzKmWibEqgC_wrPVfBJu8iBHMebhXA1afSZZ6mZMQmg&usqp=CAU';
    }

    let file = await this.fileService.GetFileFromFirebase(fileName);

    return file;
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

  pageChanged(event: any): void {
    this.page = event.page + 1;
    this.itemsPerPage = event.rows;
    this.loadStudentList({
      page: this.page,
      itemsPerPage: this.itemsPerPage,
    });
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  showDialog() {
    this.visible = true;
  }

  addStudents() {
    let ids = [];
    this.selectedStudents.forEach((element) => {
      ids.push(element.value);
    });

    let data: AddStudentInClassRequest = {
      classId: this.classId,
      studentIds: ids,
    };
    
    this.classService.addStudent(data).subscribe({
      next: () => {
        this.notificationService.showSuccess(MessageConstants.CREATED_OK_MSG);
        this.loadStudentList();
        this.selectedStudents = [];
        this.toggleBlockUI(false);
      },
      error: () => {
        this.notificationService.showError(MessageConstants.CREATED_FALL_MSG);
      },
    });
  }

  activeIndex: number = -1; // Khởi tạo activeIndex với giá trị mặc định

  onTabClick(index: number) {
    if (this.activeIndex === index) {
      // Nếu tab đã được chọn rồi, bỏ chọn nó
      this.activeIndex = null;
      this.selectedItemsProject = [];
    } else {
      // Nếu tab chưa được chọn, chọn nó và cập nhật selectedItems
      this.activeIndex = index;
      this.selectedItemsProject = [this.itemsProject[index]];
    }
  }
}
