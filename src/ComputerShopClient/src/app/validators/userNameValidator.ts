import { AuthService } from "../services/auth.service";
import { ValidatorFn, AbstractControl, FormControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { map, flatMap, switchMap, debounceTime, take } from 'rxjs/operators';
import { forkJoin, Observable, timer } from 'rxjs/index';


export class UserNameValidator {
    public static userNameExists(authService: AuthService): AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => {
            return authService.checkUserName(control.value).pipe(
                map(res => {
                    return res ? null : { busy: true };
                })
            );
        }
    }
}