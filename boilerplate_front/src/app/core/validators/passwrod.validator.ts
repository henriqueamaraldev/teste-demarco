import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function passwordStrengthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) return null;

    const hasUpperCase = /[A-Z]/.test(value);
    const hasLowerCase = /[a-z]/.test(value);
    const hasDigit = /\d/.test(value);

    const valid = hasUpperCase && hasLowerCase && hasDigit;

    return valid
      ? null
      : {
        passwordStrength: {
          hasUpperCase,
          hasLowerCase,
          hasDigit,
        },
      };
  };
}

export function mustMatch(controlName: string, matchingControlName: string): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const control = formGroup.get(controlName);
    const matchingControl = formGroup.get(matchingControlName);

    if (!control || !matchingControl) return null;

    const isMatching = control.value === matchingControl.value;

    return isMatching ? null : { mustMatch: true };
  };
}