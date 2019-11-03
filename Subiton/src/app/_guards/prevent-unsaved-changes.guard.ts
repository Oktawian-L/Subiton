import { CanDeactivate } from '@angular/router';
import { UserEditComponent } from '../users/user-edit/user-edit.component';

export class PreventUnsavedChanges implements CanDeactivate<UserEditComponent> {

  canDeactivate(component: UserEditComponent) {
    if (component.editForm.dirty) {
      return confirm('You have unsaved changes. Are you sure?');
    }
    return true;
  }
  
}
