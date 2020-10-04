import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss']
})
export class ProductViewComponent implements OnInit {

  sideNavOpened = false;

  constructor() {
    this.initScripts();
  }

  ngOnInit(): void {
  }

  initScripts(){
    let testScript = document.createElement("script");
    testScript.setAttribute("src", "../../../assets/js/header/InitWithColor.js");
    document.body.appendChild(testScript);
  }

}
