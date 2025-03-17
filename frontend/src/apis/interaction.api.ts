import { AxiosResponse } from "axios";
import { Interaction } from "../models/interaction.interface";
import fetchAPI from "../utils/fetchApi";

export const getAllInteractions = async (currentAccountId: number, otherAccountId: number) => {
    const response: AxiosResponse<Interaction[]> = await fetchAPI.request({
        url: "/Interaction/get-all-interactions",
        method: "get",
        params: {
            currentAccountId,
            otherAccountId,
        },
    });

    return response.data;
};
