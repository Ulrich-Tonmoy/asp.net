import { Component, OnInit } from '@angular/core';
import { SubService } from 'src/app/core/services/sub.service';
import { Sub } from '@shared/libs';
import { ToastrService } from 'ngx-toastr';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-subscribers',
  templateUrl: './subscribers.component.html',
  styleUrls: ['./subscribers.component.scss'],
})
export class SubscribersComponent implements OnInit {
  subs: Array<Sub> = [];

  constructor(private subService: SubService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.getAllSubs();
  }

  onDelete = (id: any, email: string) => {
    if (confirm(`Are you sure you want to delete subscription of ${email}?`)) {
      this.subService
        .deleteSub(id)
        .pipe(takeUntilDestroyed())
        .subscribe((_response: any) => {
          this.toastr.warning(
            `Subscriber with '${email}' deleted successfully!`
          );
        });
      this.getAllSubs();
    }
  };

  getAllSubs = () => {
    this.subService
      .getSubs()
      .pipe(takeUntilDestroyed())
      .subscribe((data) => {
        this.subs = data;
      });
  };
}
