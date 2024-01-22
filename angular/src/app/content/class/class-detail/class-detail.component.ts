import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, MenuItem } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';
import { AddStudentInClassRequest, ClassClient, ClassDto, FileParameter, ProjectClient, ProjectDto, ProjectResponse, StudentDto, StudentResponse, UserClient, UserDto, UserResponse } from 'src/app/api/api-generate';
import { MessageConstants } from 'src/app/shared/constants/message.const';
import { FileService } from 'src/app/shared/services/file.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { UtilityService } from 'src/app/shared/services/utility.service';
import { ProjectModalComponent } from '../project-modal/project-modal.component';

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

  public projectStatus: any;

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
        false,
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

  //Paging variables
  public pageProject: number = 1;
  public itemsPerPageProject: number = 5;
  public totalCountProject: number;
  public keyWordsProject: string | null;
  public skipProject: number | null;
  public takeProject: number | null;
  public sortFieldProject: string | null;
  loadDataProjects() {
    this.toggleBlockUI(true);
    this.projectService
      .projectGET(
        this.classId,
        this.projectStatus,
        this.keyWordsProject,
        this.pageProject,
        this.itemsPerPageProject,
        this.skipProject,
        this.takeProject,
        this.sortFieldProject
      )
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: ProjectResponse) => {
          this.itemsProject = response.projects;
          this.totalCountProject = response.page.toTalRecord;
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }

  pageProjectChanged(event: any): void {
    this.pageProject = event.pageProject + 1;
    this.itemsPerPageProject = event.rows;
    this.loadDataProjects();
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

  downLoadTemplateExcel() {
    this.classService.downTemplateAddStudents().subscribe(
      (response: any) => {
        const blob = new Blob([response], {
          type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        });
        const url = window.URL.createObjectURL(blob);

        // Tạo một thẻ <a> để tải xuống tệp Excel
        const a = document.createElement('a');
        a.href = url;
        a.download = 'template-add-student.xlsx';
        document.body.appendChild(a);
        a.click();

        // Giải phóng URL tạm thời
        window.URL.revokeObjectURL(url);
      },
      (error) => {
        console.error('Lỗi khi tải xuống tệp: ', error);
      }
    );
  }

  importAddStudents(event: any) {
    let files = event.files;
    if (files && files.length > 0) {
      const file = files[0];
      const reader = new FileReader();
      reader.onload = (event) => {
        const fileData = event.target.result as ArrayBuffer;
        const blob = new Blob([fileData], {
          type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        });

        const formFile: FileParameter = {
          data: blob,
          fileName: file.name,
        };
        this.classService
          .importStudents(this.classId, formFile)
          .pipe(takeUntil(this.ngUnsubscribe))
          .subscribe(
            (response) => {
              // Xử lý khi file được upload thành công (nếu cần)
              console.log('File uploaded successfully:', response);
            },
            (error) => {
              // Xử lý khi có lỗi xảy ra trong quá trình upload file
              console.error('Error uploading file:', error);
            }
          );
      };
      reader.readAsArrayBuffer(file);
    }
  }

  showDialogCreateProject() {
    const ref = this.dialogService.open(ProjectModalComponent, {
      header: 'Add new project',
      width: '70%',
      data: {
        classId: this.classId,
      },
    });

    ref.onClose.subscribe((isSuccess: boolean) => {
      if (isSuccess == true) {
        this.notificationService.showSuccess(MessageConstants.CREATED_OK_MSG);
        this.loadDataProjects();
      }
      if (isSuccess == false) {
        this.notificationService.showError(MessageConstants.CREATED_FALL_MSG);
      }
    });
  }

  updateProject(projectId: number) {
    const ref = this.dialogService.open(ProjectModalComponent, {
      header: 'Update project',
      width: '70%',
      data: {
        classId: this.classId,
        projectId: projectId,
      },
    });

    ref.onClose.subscribe((isSuccess: boolean) => {
      if (isSuccess == true) {
        this.notificationService.showSuccess(MessageConstants.UPDATED_OK_MSG);
        this.loadDataProjects();
      }
      if (isSuccess == false) {
        this.notificationService.showError(MessageConstants.UPDATED_FALL_MSG);
        this.loadDataProjects();
      }
    });
  }
}
