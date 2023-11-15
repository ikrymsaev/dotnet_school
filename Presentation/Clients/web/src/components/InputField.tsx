import { Button } from "antd";

interface IProps {
  text: string;
  description: string;
  handleInput: (e: string) => void;
  handleSubmit: () => void;
  handleSetDescription: (e: string) => void
}

export const InputField = (props: IProps) => {
  const {text, description, handleInput, handleSubmit, handleSetDescription} = props;

  return (
    <label>
            <input placeholder="название" value={text} onChange={(e) => handleInput(e.target.value)}/>
            <br/>
            <input placeholder="описание" value={description} onChange={(e) => handleSetDescription(e.target.value)}/>
            <br/>
            <Button onClick={handleSubmit} type='primary' size='large'>Add Lesson</Button>
    </label>
  )
}
