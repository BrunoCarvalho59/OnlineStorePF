import { Component } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize, map } from 'rxjs';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-registo',
  templateUrl: './registo.component.html',
  styleUrls: ['./registo.component.scss']
})
export class RegistoComponent {
  errors: string[] | null = null;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {}

  complexPassword = "(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$"

  registerForm = this.fb.group ({
    displayNome: ['', Validators.required],
    email: ['', [Validators.required, Validators.email], [this.validateEmailNotTaken()]],
    password: ['', [Validators.required, Validators.pattern(this.complexPassword)]]
  })

  onSubmit() {
    this.accountService.registo(this.registerForm.value).subscribe({
      next: () => this.router.navigateByUrl('/loja'),
      error: error => this.errors = error.errors
    })
  }

  validateEmailNotTaken(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      return this.accountService.checkEmailExists(control.value).pipe(
        map(result => result ? {emailExists: true} : null),
        finalize(() => control.markAsTouched)
      )
    }
  }
}
