export interface Post {
  id?: number;
  title: string;
  permaLink: string;
  category: {
    id: string;
    name: string;
  };
  heroImg: string;
  excerpt: string;
  content: string;
  isFeatured: boolean;
  views: number;
  status: string;
  createdAt: Date;
}
