import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ProjectDto, CreateProjectDto, ProjectClient } from '../../../api/api-generate';
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
  /**
   *
   */
  constructor(
    private fb: FormBuilder,
    private utilService: UtilityService,
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef,
    private projectService: ProjectClient
  ) {}

  ngOnInit(): void {
    this.initFormData();
    this.buildFormProject();
  }

  initFormData() {
    this.classId = this.config.data.classId;
    if (this.utilService.isEmpty(this.config.data?.id) == false) {
    }
  }
  saveChangeProject() {
    this.projectService.projectPOST(this.form.value).pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: () => {
          this.ref.close(true);
        },
        error: () => {
          this.ref.close(false);
        }
      });
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
