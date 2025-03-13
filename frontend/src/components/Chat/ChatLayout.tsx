"use client"
import MessageInput from "./MessageInput"
import ChatArea from "./ChatArea"

export default function ChatLayout() {
  return (
    <div className="w-[700px] mx-auto bg-white rounded-2xl shadow-lg flex flex-col">
      {/* Chat Area */}
      <ChatArea />
      {/* Message Input */}
      <MessageInput />
    </div>
  )
}

