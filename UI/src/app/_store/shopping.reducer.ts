import { ShoppingItem } from "../_models/models";
import { ShoppingAction, ShoppingActionTypes } from "./shopping.actions";

const initialState: ShoppingItem[] = [];

export function ShoppingReducer(state: ShoppingItem[] = initialState, action: any) {

    switch (action.type) {
        // Add
        case ShoppingActionTypes.ADD_ITEM:
            return [...state, action.payload];
        // Delete Single
        case ShoppingActionTypes.DELETE_ITEM:
            return state.filter(item => item.id !== action.payload);
        // Delete All
        case ShoppingActionTypes.DELETE_All_ITEM:
            return [];
        // Update
        case ShoppingActionTypes.UPDATE_ITEM:
            state.map(newsItem => {
                if (newsItem.id === action.payload.id) {
                    return [newsItem, action.payload];
                }
                return state;
              });
            return state;
        default:
            return state;
    }
}
