import { ITodo } from "../models/Todo";
import { IBoard } from "../models/IBoard";
import { history } from "../../index";
import axios, { AxiosResponse } from "axios";
import { toast } from "react-toastify";

axios.defaults.baseURL = "http://localhost:5000/api";
axios.defaults.headers = { "Access-Control-Allow-Origin": "*" };
axios.interceptors.response.use(undefined, (error) => {
  console.log(error);
  if (error.message === "Network Error" && !error.response) {
    toast.error("Network Error - make sure API is running!");
  }
  const { data, config } = error?.response;
  console.log(error);
  if (error.response.status === 404) {
    history.push("/notfound");
  }
  if (
    error.response.status === 400 &&
    config.method === "get" &&
    data.errors.hasOwnProperty("id")
  ) {
    history.push("/notfound");
  }
  if (error.response.status === 500) {
    toast.error("Server error -check the terminal for more info!");
  }
  throw error;
});
const responseBody = (response: AxiosResponse) => response?.data;

const request = {
  get: (url: string) => axios.get(url).then(sleep(1000)).then(responseBody),
  post: (url: string, body: {}) =>
    axios.post(url, body).then(sleep(1000)).then(responseBody),
  put: (url: string, body: {}) =>
    axios.put(url, body).then(sleep(1000)).then(responseBody),
  del: (url: string) => axios.delete(url).then(sleep(1000)).then(responseBody),
};

const sleep = (ms: number) => (response: AxiosResponse) =>
  new Promise<AxiosResponse>((resolve) =>
    setTimeout(() => resolve(response), ms)
  );

export const Todos = {
  list: (): Promise<ITodo[]> => request.get("/todo"),
  details: (id: number) => request.get(`/todo/${id}`),
  create: (todo: ITodo) => request.post("/todo", todo),
  update: (todo: ITodo) => request.put(`/todo/${todo.id}/`, todo),
  delete: (id: number) => request.del(`/todo/${id}`),
};

export const Boards = {
  list: (): Promise<IBoard[]> => request.get("/board"),
  details: (id: number) => request.get(`/board/${id}`),
  create: (board: IBoard) => request.post("/board", board),
  update: (board: IBoard) => request.put(`/board/${board.id}/`, board),
  delete: (id: number) => request.del(`/board/${id}`),
  updateBoards: (boards: IBoard[]) => request.put(`/board/EditBoards`, boards),
};
