import { Component, OnInit } from '@angular/core';
import { IActivitie } from 'src/app/models/activitie';
import { ACTIVITIES_MOCK } from 'src/app/mocks/activities_mock';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivitiesService } from 'src/app/services/activities/activities.service';

@Component({
  selector: 'pro-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.scss']
})
export class ActivitiesComponent implements OnInit {

  activities: IActivitie[] = []; //ACTIVITIES_MOCK
  formActivitie: FormGroup = new FormGroup({});

  page = 1;
  pageSize = 20;
  newActivitie: IActivitie = {
      title: "",
      description: ""
  }

  constructor(config: NgbModalConfig, private modalService: NgbModal, private formBuilder: FormBuilder, private activitiesService: ActivitiesService) {
		config.backdrop = 'static';
		config.keyboard = false;

    this.formActivitie = formBuilder.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
  });
	}

  ngOnInit(): void {
    this.getAllActivities();
  }

  open(content: any) {
		this.modalService.open(content);
	}

  CreateActivitie(){
    this.newActivitie.title = this.formActivitie.value.title
    this.newActivitie.description = this.formActivitie.value.description
    // Chama função na service para executar o post
    this.activitiesService.postActivitie(this.newActivitie);
    this.modalService.dismissAll();
  }

  getAllActivities(){
    this.activitiesService.getAllActivities()
    .subscribe((activities: IActivitie[]) => {
      this.activities = activities
    });
  }
}
