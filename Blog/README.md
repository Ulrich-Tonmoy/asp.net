# Blog App

In this app theres two part one for anyone to read blog and another for only logged in users to post blogs, categories and manage them. This is a single administration app where only the admin have the permissions to create, update and delete categories, posts and subscriptions.

### Blog

In the home page user will be able to see top featured (max 4) posts and latests (max 6) posts. And there will be a list of categories for user to view post based on the categories. In the single post page where all the details are shown user will be give a list of similar post suggestions.

<p align="center">
  <img alt="home" src="./docs/1.png" width="330px"/>
  <img alt="home" src="./docs/2.png" width="330px"/>
  <img alt="home" src="./docs/3.png" width="330px"/>
  <img alt="category" src="./docs/4.png" width="330px"/>
  <img alt="post" src="./docs/5.png" width="330px"/>
</p>

### Dashboard

The dashboard route and sub-routes are secured using auth guard user cant go to these page without logging in. In dashboard home page user will have all the navigation card (i.e category, posts, subscriptions) to goto the specific page to manage these. From category page user will be able to create, update and delete categories same for the posts page and in the subscriptions page user will be able to remove any email from subscription list.

<p align="center">
  <img alt="login" src="./docs/6.png" width="330px"/>
  <img alt="dashboard" src="./docs/7.png" width="330px"/>
  <img alt="category" src="./docs/8.png" width="330px"/>
  <img alt="posts" src="./docs/9.png" width="330px"/>
  <img alt="new post" src="./docs/10.png" width="330px"/>
  <img alt="all subscriber" src="./docs/11.png" width="330px"/>
</p>