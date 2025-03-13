export default function ChatArea() {

    return (
      <div className="flex-1 overflow-y-auto p-6">
      <div className="mx-auto max-w-4xl space-y-6">
        {/* Received Message */}
        <div className="flex items-start gap-2.5">
        <div className="h-8 w-8 rounded-full bg-blue-500 p-2">
          <div className="h-full w-full text-white">🤖</div>
        </div>
            <div className="max-w-[80%] rounded-2xl rounded-tl-none bg-gray-100 px-4 py-2">
              <p className="text-sm text-gray-900">Hello! How can I help you today?</p>
            </div>
          </div>

          {/* Sent Message */}
          <div className="flex items-start justify-end gap-2.5">
            <div className="max-w-[80%] rounded-2xl rounded-tr-none bg-[#4F6EF7] px-4 py-2">
              <p className="text-sm text-white">Hi! I have a question about the new features.</p>
            </div>
          </div>

          {/* Received Message */}
          <div className="flex items-start gap-2.5">
            <div className="h-8 w-8 rounded-full bg-blue-500 p-2">
              <div className="h-full w-full text-white">🤖</div>
            </div>
            <div className="max-w-[80%] rounded-2xl rounded-tl-none bg-gray-100 px-4 py-2">
              <p className="text-sm text-gray-900">
                Of course! I&apos;d be happy to help explain the new features. What would you like to know?
              </p>
            </div>
          </div>

          {/* Sent Message */}
          <div className="flex items-start justify-end gap-2.5">
            <div className="max-w-[80%] rounded-2xl rounded-tr-none bg-[#4F6EF7] px-4 py-2">
              <p className="text-sm text-white">Could you tell me more about the new chat interface?</p>
            </div>
          </div>
        </div>
      </div>
    )
}