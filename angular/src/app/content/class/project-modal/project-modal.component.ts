import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProjectDto, CreateProjectDto, ProjectClient, MemberDto, UserDto, ClassClient, StudentResponse } from '../../../api/api-generate';
import { UtilityService } from 'src/app/shared/services/utility.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-project-modal',
  templateUrl: './project-modal.component.html',
})
export class ProjectModalComponent implements OnInit {
  private ngUnsubscribe = new Subject<void>();
  public form: FormGroup;
  createProjectRequest = {} as CreateProjectDto;
  classId: number;
  public btnSaveName: string;

  public members: MemberDto[];

  public studentsInClass: any[]=[];
  public selectedStudents: any[]=[];
  /**
   *
   */
  constructor(
    private fb: FormBuilder,
    private utilService: UtilityService,
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef,
    private projectService: ProjectClient,
    public classService: ClassClient,
  ) {}

  ngOnInit(): void {
    this.classId = this.config.data.classId;
    this.buildFormProject();
    this.initFormData();
    this.loadStudentsHaveNotProjectInClass(this.classId);
  }

  loadStudentsHaveNotProjectInClass(classId: number) {
    this.classService.studentsList(classId,true, undefined, undefined, undefined, undefined, undefined, undefined)
    .pipe(takeUntil(this.ngUnsubscribe))
    .subscribe((response: StudentResponse) => {
      response.students.forEach((s) => {
        this.studentsInClass.push({
          label: s.email,
          value: s.id,
        });
      })
    })
  }

  initFormData() {
    if (this.utilService.isEmpty(this.config.data?.projectId) == false) {
      this.loadDetailProject(this.config.data?.projectId);
    }
  }

  loadDetailProject(id: number) {
    this.projectService
      .projectGET2(id)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response) => {
          this.createProjectRequest = response;
          this.members = response.projectMembers;
          this.buildFormProject();
        },
        error: () => {
          console.log('error');
        },
      });
  }

  saveChangeProject() {
    if (this.utilService.isEmpty(this.config.data?.projectId) == true) {
      this.projectService
        .projectPOST(this.form.value)
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe({
          next: () => {
            this.ref.close(true);
          },
          error: () => {
            this.ref.close(false);
          },
        });
    } else {
      let projectId: number = this.config.data?.projectId;
      this.projectService
        .projectPUT(projectId, this.form.value)
        .pipe(takeUntil(this.ngUnsubscribe))
        .subscribe({
          next: () => {
            this.ref.close(true);
          },
          error: () => {
            this.ref.close(false);
          },
        });
    }
  }

  validationMessages = {
    name: [
      { type: 'required', message: 'Name Requirement' },
      { type: 'minlength', message: 'Not more 255 characters' },
      { type: 'maxlength', message: 'Have to greater than 3 characters' },
    ],
    description: [
      { type: 'required', message: 'Have to greater than 3 characters' },
    ],
  };

  buildFormProject() {
    this.form = this.fb.group({
      name: new FormControl(
        this.createProjectRequest.name || null,
        Validators.compose([
          Validators.required,
          Validators.maxLength(255),
          Validators.minLength(3),
        ])
      ),
      description: new FormControl(
        this.createProjectRequest.description || null,
        Validators.compose([Validators.required, Validators.minLength(10)])
      ),
      classId: new FormControl(this.classId),
    });
  }
}
