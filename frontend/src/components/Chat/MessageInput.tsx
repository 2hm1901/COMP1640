import { useState } from "react"
import { PaperclipIcon, SendIcon } from "lucide-react"
export default function MessageInput() {
    const [message, setMessage] = useState("")
    return (
        <div className=" p-4">
        <div className="mx-auto max-w-4xl">
          <div className="flex items-center gap-2 rounded-full border border-gray-200 bg-white px-4 py-2">
            <input
              type="text"
              placeholder="Write your message"
              className="flex-1 border-none text-sm outline-none placeholder:text-gray-400"
              value={message}
              onChange={(e) => setMessage(e.target.value)}
            />
            <button className="p-1 text-gray-400 hover:text-gray-600">
              <PaperclipIcon className="h-5 w-5" />
              <span className="sr-only">Attach file</span>
            </button>
            <button className="rounded-full bg-[#4F6EF7] p-2 text-white hover:bg-blue-600">
              <SendIcon className="h-4 w-4" />
              <span className="sr-only">Send message</span>
            </button>
          </div>
        </div>
      </div>
        )
        }