import { User } from '../../models/user';

export interface IAuthState {
  user: User | null;
  hasError: boolean;
  errorMessage: string | null;
  isAuthenticated: boolean;
  isLoading: boolean;
}

export const initialAuthState: IAuthState = {
  user: null,
  hasError: false,
  errorMessage: null,
  isAuthenticated: false,
  isLoading: false
};
