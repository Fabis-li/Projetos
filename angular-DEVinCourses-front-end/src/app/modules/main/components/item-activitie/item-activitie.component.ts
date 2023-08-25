import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { IActivitie } from 'src/app/models/activitie';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivitiesService } from 'src/app/services/activities/activities.service';


@Component({
  selector: 'pro-item-activitie',
  templateUrl: './item-activitie.component.html',
  styleUrls: ['./item-activitie.component.scss']
})
export class ItemActivitieComponent implements OnInit {

  @Input()
  item: IActivitie = {
    id: 0,
    title: '',
    description: ''
  }

  formEdit: FormGroup = new FormGroup({});

  open(content: any) {
		this.modalService.open(content);
	}

  constructor(config: NgbModalConfig, private modalService: NgbModal, private formBuilder: FormBuilder, private activitiesService: ActivitiesService) {
		config.backdrop = 'static';
		config.keyboard = false;

    this.formEdit = formBuilder.group({
      description: ['', [Validators.required]],
  });
  	}

  ngOnInit(): void {
  }

  editActivitie(){
    this.item.description = this.formEdit.value.description;
    this.activitiesService.putActivities(this.item.title, this.item);
    this.modalService.dismissAll();
  }

  deleteAtivitie(title:string){
    this.activitiesService.deleteActivitie(title);
  }
}
