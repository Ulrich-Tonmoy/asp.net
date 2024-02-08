import { Component } from '@angular/core';
import { SubService } from 'src/app/core/services/sub.service';
import { Sub } from '@shared/libs';
import { ToastrService } from 'ngx-toastr';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-subscription-form',
  templateUrl: './subscription-form.component.html',
  styleUrls: ['./subscription-form.component.scss'],
})
export class SubscriptionFormComponent {
  isSubscribed: boolean = false;

  constructor(private subService: SubService, private toastr: ToastrService) {}

  onSubmit(data: Sub): void {
    this.subService
      .checkSubscription(data.email)
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        if (!data) {
          this.subService
            .addSub(data)
            .pipe(takeUntilDestroyed())
            .subscribe((response: any) => {
              this.toastr
                .success(`Thank you for subscribing to our newsletter service. Stay tuned for
            awesome blog posts...`);
            });
        } else {
          this.toastr.warning(`Email '${data.email}' is already subscribed!`);
        }
        this.isSubscribed = true;
      });
  }
}
