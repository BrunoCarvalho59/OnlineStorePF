export interface User {
  email: string;
  displayNome:string;
  token:string;
}

export interface Morada {
  primeiroNome: string;
  ultimoNome: string;
  rua: string;
  localidade: string;
  country: string;
  zip: string;
}
