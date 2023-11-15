import { FC } from "react";
import { Link } from "react-router-dom";

interface IProps {
    id: string;
    title?: string;
    description?: string;
    completed?: boolean;
  }

export const LessonItem: FC<IProps> = ({id, title, description}) => {

  return (
    <li>
      <Link key={id} to={`/lesson/${id}`} state={{ title, description }}>
        <span>{title}  </span>
        <span>{description}</span>
      </Link>
    </li>
  )
}
