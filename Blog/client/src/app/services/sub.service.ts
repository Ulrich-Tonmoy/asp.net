import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Sub } from '../models/sub';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SubService {
  constructor(private http: HttpClient, private toastr: ToastrService) {}

  addSub = (sub: Sub) => {
    this.checkSubscription(sub.email).subscribe((data) => {
      if (data.length === 0) {
        this.http.post('http://localhost:3000/subs', sub).subscribe(
          (response: any) => {
            console.log(response);
            this.toastr
              .success(`Thank you for subscribing to our newsletter service. Stay tuned for
            awesome blog posts...`);
          },
          (error: any) => {
            this.toastr.error('Error occurred adding Subscription!');
            this.toastr.error(error);
          }
        );
      } else {
        this.toastr.warning(`Email '${sub.email}' is already subscribed!`);
      }
    });
  };

  checkSubscription = (email: string) => {
    return this.http
      .get(`http://localhost:3000/subs?email=${email}`)
      .pipe(map((actions: any) => actions));
  };

  getSubs = () => {
    return this.http
      .get('http://localhost:3000/subs')
      .pipe(map((actions: any) => actions));
  };

  deleteSub = (id: string, email: string) => {
    this.http.delete(`http://localhost:3000/subs/${id}`).subscribe(
      (response: any) => {
        console.log(response);
        this.toastr.warning(`Subscriber with '${email}' deleted successfully!`);
      },
      (error: any) => {
        this.toastr.error('Error occurred deleting Subscriber!');
        this.toastr.error(error);
      }
    );
  };
}
