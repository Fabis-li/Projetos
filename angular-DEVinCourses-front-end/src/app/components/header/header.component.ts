import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { USER_MOCK } from 'src/app/mocks/user_mock';
import { IUser } from 'src/app/models/user';
import { TrainingService } from 'src/app/services/training/training.service';

@Component({
  selector: 'pro-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  userActive!: IUser; 
  profilePicture!:any;
  
  constructor(private trainingService:TrainingService,
    private router:Router) { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser(){
    this.trainingService.getUserByToken(this.trainingService.token)
    .subscribe((user:IUser) => {
      this.userActive = user;
      this.profilePicture = this.userActive?.image;

      if(this.userActive.image == null){
        this.profilePicture = "https://www.promoview.com.br/uploads/2017/04/b72a1cfe.png";
      }
    })
  }

  logoff(){
    localStorage.removeItem("token");
    this.router.navigate(['login']);
  }

}
