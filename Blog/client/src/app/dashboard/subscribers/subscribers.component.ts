import { Component, OnInit } from '@angular/core';
import { Sub } from 'src/app/models/sub';
import { SubService } from 'src/app/services/sub.service';

@Component({
  selector: 'app-subscribers',
  templateUrl: './subscribers.component.html',
  styleUrls: ['./subscribers.component.scss'],
})
export class SubscribersComponent implements OnInit {
  subs: Array<Sub> = [];

  constructor(private subService: SubService) {}

  ngOnInit(): void {
    this.getAllSubs();
  }

  onDelete = (id: any, email: string) => {
    if (confirm(`Are you sure you want to delete subscription of ${email}?`)) {
      this.subService.deleteSub(id, email);
      this.getAllSubs();
    }
  };

  getAllSubs = () => {
    this.subService.getSubs().subscribe((data) => {
      this.subs = data;
    });
  };
}
