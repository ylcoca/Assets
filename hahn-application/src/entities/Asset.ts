import { User } from "./User";

export class Asset {
  public id: string;
  public rank: number;
  public name: string;
  public supply: number;
  public maxSupply: number;
  public marketCapUsd: number;
  public volumeUsd24Hr: number;
  public priceUsd: number;
  public user: User;
}
