import {IAppState} from "../states/app.states";
import {createSelector} from "@ngrx/store";
import {IAuthState} from "../states/auth.states";

export const selectAuth = (state: IAppState) => state.authState;

export const selectUser = createSelector(
  selectAuth,
  (state: IAuthState) => state.user
);

export const selectError = createSelector(
  selectAuth,
  (state: IAuthState) => state.errorMessage
);

export const getLoggedIn = createSelector(
  selectAuth,
  (state: IAuthState) => state.isAuthenticated
);

export const getLoading = createSelector(
  selectAuth,
  (state: IAuthState) => state.isLoading
);
