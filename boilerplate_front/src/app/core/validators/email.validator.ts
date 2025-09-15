import { AbstractControl, ValidationErrors } from '@angular/forms';

export function ExtendedEmailValidator(control: AbstractControl): ValidationErrors | null {
  const email = control.value;
  const regex = /^[\w.%+-]+@[A-Z0-9.-]+\.(com|org|net|edu|gov|br|co|io|ai|dev|info)$/i;

  if (!email) return null;
  return regex.test(email) ? null : { extendedEmail: true };
}
