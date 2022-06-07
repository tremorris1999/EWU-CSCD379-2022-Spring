
import { NuxtAxiosInstance } from '@nuxtjs/axios'
class WordleToken {

    Random: string = "";
    UserId: string= "";
    UserName: string= "";
    aud: string= "";
    exp: number = 0
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":string[] = []
    iss: string= "";
    jti: string= "";
    sub: string= "";
    get roles(): string[] {
        return this["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    }

}
export class JWT {
    private static tokenInstance: string;
    private static _tokenData: WordleToken;

    public static setToken(token:string, axios: NuxtAxiosInstance) {
        this.tokenInstance = token;
        axios.setHeader('Authorization', `Bearer ${token}`);
        const parts = token.split('.');
        const payload = JSON.parse(atob(parts[1]));
        this._tokenData = Object.assign(new WordleToken, payload);
    }

    public static getToken(): string {
        return this.tokenInstance;
    }

    public static get tokenData(): WordleToken {
        return this._tokenData;
    }
}
