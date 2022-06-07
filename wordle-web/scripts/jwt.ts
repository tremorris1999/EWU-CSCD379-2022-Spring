
import { NuxtAxiosInstance } from '@nuxtjs/axios'

export class JWT {
    private static tokenInstance: string;
    private static _tokenData: any;

    public static setToken(token:string, axios: NuxtAxiosInstance) {
        this.tokenInstance = token;
        axios.setHeader('Authorization', `Bearer ${token}`);
        const parts = token.split('.');
        const payload = JSON.parse(atob(parts[1]));
        this._tokenData = payload;
    }

    public static getToken(): string {
        return this.tokenInstance;
    }

    public static get tokenData(): any {
        return this._tokenData;
    }
}
