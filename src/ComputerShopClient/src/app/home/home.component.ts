import { Component, OnInit } from '@angular/core';
import {HomeService} from '../services/home.service';
import { AuthService } from '../services/auth.service';
import { takeUntil } from 'rxjs/operators';
import { DestroyService } from '../services/destroy.service';
import { HttpHeaders } from '@angular/common/http';

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
    this.authService.inventoryChanger$.pipe(takeUntil(this.destroy$)).subscribe(sbj =>{
      if(sbj){
        this.homeService.getData().subscribe(data => this.data = data);
      }else{
        this.data = null;
      }
    },
    errorMsg =>{
      this.getDataError = <any>errorMsg;
    });
  }

}
