import {
  Directive,
  ElementRef,
  Input,
  OnChanges,
  SimpleChanges,
} from '@angular/core';

@Directive({
  selector: '[rating]',
})
export class RatingStarDirective implements OnChanges {
  @Input() rating: number = 0;

  constructor(private el: ElementRef) {}

  ngOnChanges(changes: SimpleChanges): void {
    let fullStar = Math.floor(this.rating);
    let halfStar = this.rating > Math.floor(this.rating) ? 1 : 0;
    let emptyStar = 5 - fullStar - halfStar;

    if (this.rating > 0)
      this.el.nativeElement.innerHTML +=
        '★'.repeat(fullStar) + '✪'.repeat(halfStar) + '☆'.repeat(emptyStar);
    else this.el.nativeElement.innerHTML += '☆'.repeat(5);
  }
}

// How to use
// <p [rating]="user.rating"></p>