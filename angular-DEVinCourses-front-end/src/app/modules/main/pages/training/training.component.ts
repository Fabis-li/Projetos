import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { TRAININGBYUSER_MOCK } from 'src/app/mocks/trainingsByUser_mock';
import { TRAINING_MOCK } from 'src/app/mocks/training_mock';
import { IRegistration } from 'src/app/models/registration';
import { ITraining } from 'src/app/models/training';
import { ITraningByUser } from 'src/app/models/trainingByUser';
import { IUser } from 'src/app/models/user';
import { TrainingService } from 'src/app/services/training/training.service';

@Component({
  selector: 'pro-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.scss'],
})
export class TrainingComponent implements OnInit {

  trainingsByUser: ITraining[] = [];
  UserActive!:IUser;

  status: string = 'todos';
  filters: ITraining[] = [];

  userId!: number;

  page = 1;
  pageSize = 20;

  constructor(private trainingService:TrainingService,
    private serviceTitle:Title) {}


  ngOnInit():void {
    this.serviceTitle.setTitle('NDD Training - My Training');
    this.getUserActive();
  }

  getUserActive(){
    this.trainingService.getUserByToken(this.trainingService.token)
    .subscribe((user:IUser) => {
      this.UserActive = user;
      this.getMyTrainings(user?.id);
    })
  }

  getMyTrainings(id: number| undefined){
    this.trainingService.getTrainingsByUser(id)
    .subscribe((trainingsByUser:ITraining[])=>{
      this.trainingsByUser = trainingsByUser
      this.filterByStatus()
    })
  }

  getMyTrainingsByStatus(id:number | undefined, status:string){
    this.trainingService.getRegistrationByUser(id, status)
    .subscribe((registration: IRegistration[])=>{
      for (let i = 0; i < registration.length; i++) {
        this.trainingsByUser.forEach(item => {
          if(item.id == registration[i].trainingId){
            this.filters.push(item)
          }
        })
      }
    })

  }

  getRecentTrainingsByUser(id: number) {
    this.trainingService
      .getRecentTrainingsByUser(id)
      .subscribe((registration: IRegistration[]) => {
        for (let i = 0; i < registration.length; i++) {
          this.trainingsByUser.forEach((item) => {
            if (item.id == registration[i].trainingId) {
              this.filters.push(item);
            }
          });
        }
      });
  }

  filterByStatus() {
    this.filters = [];
    if (this.status == 'todos') {
      this.filters = this.trainingsByUser;
    } else if (this.status === 'Recentes') {
      this.getRecentTrainingsByUser(this.userId);
    } else {
      this.getMyTrainingsByStatus(this.UserActive.id, this.status);
    }
  }
}
