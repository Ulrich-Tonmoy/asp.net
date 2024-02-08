import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EndpointService {
  // Auth
  public static readonly login = 'api/user/login';
  public static readonly registration = 'api/user/registration';

  // Category
  public static readonly category = 'api/category';
  public static readonly categoryById = 'api/category/{id}';

  // Post
  public static readonly post = 'api/post';
  public static readonly postById = 'api/category/{id}';

  // Subscription
  public static readonly subscription = 'api/subscription';
  public static readonly subscriptionAny = 'api/subscription/any';
  public static readonly subscriptionById = 'api/subscription/{id}';
}
