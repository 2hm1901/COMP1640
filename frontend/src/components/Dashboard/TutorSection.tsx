import Image from 'next/image'
import { MessageSquare, MoreVertical } from 'lucide-react';
export default function TutorSection() {
    return (
    <div className="bg-white rounded-lg shadow-sm border border-gray-100 overflow-hidden">
    <h2 className="text-gray-800 font-medium px-4 py-3 border-b border-gray-100">Tutor</h2>
    <div className="p-4">
      <div className="flex items-start space-x-3">
        <div className="w-12 h-12 bg-gray-200 rounded-full overflow-hidden flex-shrink-0">
          <Image
            src="/placeholder.svg?height=48&width=48"
            alt="Ms. Tra"
            width={48}
            height={48}
            className="object-cover"
          />
        </div>
        <div className="flex-1">
          <h3 className="font-medium text-gray-900">Ms. Tra</h3>
          <p className="text-sm text-gray-600">Em hộp bài cho cô mau lên</p>
        </div>
        <div className="flex space-x-2">
          <button className="text-amber-500">
            <MessageSquare className="w-5 h-5" />
          </button>
          <button className="text-gray-400">
            <MoreVertical className="w-5 h-5" />
          </button>
        </div>
      </div>
    </div>
  </div>
    )
}