import {
  Directive,
  ElementRef,
  Input,
  OnChanges,
  SimpleChanges,
} from '@angular/core';

@Directive({
  selector: '[color]',
})
export class ColorDirective implements OnChanges {
  @Input() color: string = '';

  constructor(private el: ElementRef) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (this.color) this.el.nativeElement.style.color = this.color;
  }
}
