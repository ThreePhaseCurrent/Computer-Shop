import { Component, OnInit } from '@angular/core';
import {HomeService} from '../../../core/services/home.service';
import { AuthService } from '../../../core/services/auth.service';
import { takeUntil } from 'rxjs/operators';
import { DestroyService } from '../../../core/services/destroy.service';
import { HttpHeaders } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';

import * as AOS from 'aos';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [DestroyService]
})
export class HomeComponent implements OnInit {

  data: String;
  getDataError: string;

  constructor(private homeService: HomeService,
    private authService: AuthService,
    private destroy$: DestroyService) { }

  ngOnInit(): void {
      this.authService.isAuthChanger$.pipe(takeUntil(this.destroy$)).subscribe(sbj =>
        {
          if(sbj)
          {
            this.getHomeData();
          }
        },
      errorMsg =>{
        this.getDataError = <any>errorMsg;
      });

      AOS.init();
    }

  //get data from server
  getHomeData(){
    this.homeService.getData().pipe(takeUntil(this.destroy$))
              .subscribe(data => this.data = data);
  }

}
