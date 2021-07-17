import { User } from "./User";

export class Asset {
  public id: string;
  public rank: string;
  public symbol: string;
  public name: string;
  public supply: string;
  public maxSupply: string;
  public marketCapUsd: string;
  public volumeUsd24Hr: string;
  public priceUsd: string;
  public changePercent24Hr: string;
  public vwap24Hr: string;
  public explorer: string;
  public user: User;
}
