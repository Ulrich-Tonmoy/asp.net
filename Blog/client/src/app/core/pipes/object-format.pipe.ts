import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'formatObject' })
export class FormatObjectPipe implements PipeTransform {
  transform(value: any): any[] {
    if (!value) return [];
    return Object.keys(value).map((key) => ' ' + key + ': ' + value[key]);
  }
}

// How to use
// <div>{{ item | formatObject }}</div>