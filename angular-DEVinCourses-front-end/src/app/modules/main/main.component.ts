import { Component, OnInit } from '@angular/core';
import { USER_MOCK } from 'src/app/mocks/user_mock';
import { IUser } from 'src/app/models/user';
import { TrainingService } from 'src/app/services/training/training.service';

@Component({
  selector: 'pro-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  userActive!:IUser;// = USER_MOCK[0];

  constructor(private trainingService:TrainingService) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(){
    this.trainingService.getUserByToken(this.trainingService.token)
    .subscribe((user:IUser) => {
      this.userActive = user;
    })
  }

}
