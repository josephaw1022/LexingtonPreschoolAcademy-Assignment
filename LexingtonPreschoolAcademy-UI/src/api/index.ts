import axios from "axios";
import type { AxiosInstance } from "axios";

export class HttpService {
  private static client: AxiosInstance | null = null;

  public static get getInstance(): HttpService {
    return new HttpService();
  }

  private constructor() {

    if (!HttpService.client) {
      HttpService.client = axios.create({
        baseURL: process.env?.BASE_WEB_API_URL || "http://localhost:5263",
        headers: {
          "Content-Type": "application/json",
        },
      });
    }
  }

  public async get<T>(url: string) {

    if(!HttpService.client){ 
      throw new Error("HttpService.client is null")
    } 

    
    let data: T | null = null;
    let status: number | null = null;
    let error: any = null;

    await HttpService.client
      .get<T>(url)
      .then((res) => {
        data = res.data;
        status = res.status;
      })
      .catch((err) => {
        error = err;
      });

    return {
      data,
      error,
      status,
    };
  }

  public async post<T>(url: string, body: any, ...args: any[]) {

    if(!HttpService.client){
      throw new Error("HttpService.client is null")
    }

    let data: T | null = null;
    let status: number | null = null;
    let error: any = null;

    await HttpService.client
      .post<T>(url, body, ...args)
      .then((res) => {
        data = res.data;
        status = res.status;
      })
      .catch((err) => {
        error = err;
      });

    return {
      data,
      error,
      status,
    };
  }
}

