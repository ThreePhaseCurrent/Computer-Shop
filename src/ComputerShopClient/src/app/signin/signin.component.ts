import { Component, OnInit } from '@angular/core';
import { SearchCountryField, TooltipLabel, CountryISO } from 'ngx-intl-tel-input';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { UserNameValidator } from '../validators/userNameValidator';
import { map, flatMap, switchMap } from 'rxjs/operators';
import { Register } from '../models/register';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  preferredCountries: CountryISO[] = [CountryISO.Ukraine, CountryISO.Russia, CountryISO.Belarus];
  userNameValid = false;

  formResult: Register;
  resultSended: boolean;

  isAuth = false;
  regiserError;

  formErrors = {
    'firstName': '',
    'lastName': '',
    'userName': '',
    'email': '',
    'password': '',
    'phoneNumber': ''
  }

  validationsMessages = {
    'firstName': {
      'required': 'User name is required!',
    },
    'lastName': {
      'required': 'User name is required!',
    },
    'userName': {
      'required': 'User name is required!',
      'busy': 'This username is already taken!'
    },
    'email': {
      'required': 'Email is required!',
      'email': 'Invalid email!'
    },
    'password': {
      'required': 'Password is required!' 
    },
    'phoneNumber': {
      'required': 'Phone number is required!' 
    }
  };

  ngOnInit(): void {
  }

  registerForm: FormGroup;
  phoneNumber: any;
  constructor( private fb: FormBuilder,
    private authService: AuthService){
    
    this.createForm();
  }

  createForm(){
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      userName: ['', [Validators.required], [UserNameValidator.userNameExists(this.authService)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
      phoneNumber: [undefined, [Validators.required]],
  });

  this.registerForm.valueChanges
    .subscribe(data => this.onValueChanged(data));

  this.onValueChanged(); // (re)set validation messages now
  }

  onValueChanged(data?: any) {
    if (!this.registerForm) { return; }

    const form = this.registerForm;

    for (const field in this.formErrors) {

      if (this.formErrors.hasOwnProperty(field)) 
      {
        this.formErrors[field] = '';
        const control = form.get(field);

        if (control && !control.valid) 
        {
          const messages = this.validationsMessages[field];
          
          for (const key in control.errors) 
          {
            if (control.errors.hasOwnProperty(key)) 
            {
              this.formErrors[field] += messages[key] + ' ';
            }
          }
        }
      }
    }
  }

  onSubmit(){
    this.resultSended = true;
    this.formResult = this.registerForm.value;

    this.authService.register(this.formResult).subscribe(res => {
      this.resultSended = false;
      this.isAuth = true;
    },
    errmess => this.regiserError = <any>errmess);
  }

}
