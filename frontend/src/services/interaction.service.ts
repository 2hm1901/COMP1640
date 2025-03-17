import { useQuery } from "@tanstack/react-query";
import { getAllInteractions } from "../apis/interaction.api";


export const useInteractions = (currentAccountId: number, otherAccountId: number) => {
    return useQuery({
        queryKey: ["interactions", currentAccountId, otherAccountId],
        queryFn: () => getAllInteractions(currentAccountId, otherAccountId),
    });
};
