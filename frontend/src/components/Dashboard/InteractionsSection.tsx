export default function InteractionsSection(){
    return (
        <div className="bg-white rounded-lg shadow-sm border border-gray-100 overflow-hidden">
              <h2 className="text-gray-800 font-medium px-4 py-3 border-b border-gray-100">Interactions</h2>
              <div className="divide-y divide-gray-100">
                <div className="p-4 flex justify-between">
                  <div>
                    <p className="text-sm text-gray-900">Ms. Tra just uploaded a new document</p>
                  </div>
                  <span className="text-xs text-gray-500">7m ago</span>
                </div>
                <div className="p-4 flex justify-between">
                  <div>
                    <p className="text-sm text-gray-900">Ms. Tra just sent you a message</p>
                  </div>
                  <span className="text-xs text-gray-500">7m ago</span>
                </div>
                <div className="p-4 flex justify-between">
                  <div>
                    <p className="text-sm text-gray-900">Ms. Tra just commented on your document with message "..."</p>
                  </div>
                  <span className="text-xs text-gray-500">7m ago</span>
                </div>
              </div>
            </div>
    )
}