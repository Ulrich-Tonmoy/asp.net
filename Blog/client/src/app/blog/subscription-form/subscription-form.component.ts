import { Component, OnInit } from '@angular/core';
import { Sub } from 'src/app/models/sub';
import { SubService } from 'src/app/services/sub.service';

@Component({
  selector: 'app-subscription-form',
  templateUrl: './subscription-form.component.html',
  styleUrls: ['./subscription-form.component.scss'],
})
export class SubscriptionFormComponent implements OnInit {
  isSubscribed: boolean = false;

  constructor(private subService: SubService) {}

  ngOnInit(): void {}

  onSubmit(data: Sub): void {
    this.subService.addSub(data);
    this.isSubscribed = true;
  }
}
