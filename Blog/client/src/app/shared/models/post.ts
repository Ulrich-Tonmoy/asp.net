export interface Post {
  id?: string;
  title: string;
  permaLink: string;
  categoryId?: string;
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
