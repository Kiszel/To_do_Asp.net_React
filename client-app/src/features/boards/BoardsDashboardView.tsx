import React from "react";
import { IBoard } from "../../app/models/IBoard";
import "@atlaskit/css-reset";
import styled from "styled-components";
import Board from "./Board";

interface IBoardsDashboardView {
  boards: IBoard[];
}
const Container = styled.div`
  display: flex;
`;


export const BoardsDashboardView: React.FC<IBoardsDashboardView> = ({ boards }) => {
  console.log(boards);
  return (
    <Container>
      {boards.map((board: IBoard, index: number) => {
        return <Board index={index} key={board.id} board={board} />;
      })}
    </Container>
  );
};
