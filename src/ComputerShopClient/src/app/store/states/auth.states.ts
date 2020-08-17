import { User } from '../../models/user';

export interface IAuthState {
    isAuthenticated: boolean;
    user: User | null;
    errorMessage: string | null;
}

export const initialAuthState: IAuthState = {
    isAuthenticated: false,
    user: null,
    errorMessage: null
};