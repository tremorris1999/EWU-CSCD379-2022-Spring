
import { NuxtAxiosInstance } from '@nuxtjs/axios'

export class JWT {
    private static tokenInstance: string;

    public static setToken(token:string, axios: NuxtAxiosInstance) {
        this.tokenInstance = token;
        axios.setHeader('Authorization', `Bearer ${token}`);
    }

    public static getToken(): string {
        return this.tokenInstance;
    }
}
