export default function RightSection() {
    return (
        <div className="md:col-span-2 space-y-6">
            <div className="bg-white rounded-lg shadow-sm border border-gray-100 overflow-hidden">
              <h2 className="text-gray-800 font-medium px-4 py-3 border-b border-gray-100">Upcoming meetings</h2>
              <div className="divide-y divide-gray-100">
                {[1, 2, 3].map((item) => (
                  <div key={item} className="p-4">
                    <div className="flex flex-col md:flex-row md:items-center justify-between">
                      <div>
                        <h3 className="font-medium text-gray-900">COURSE_BUMINH_KIEMTRABT</h3>
                        <p className="text-sm text-gray-500">6 December 2022, 10:35 AM</p>
                      </div>
                      <div className="flex space-x-2 mt-3 md:mt-0">
                        <button className="px-4 py-1.5 bg-teal-500 text-white rounded-full text-sm">
                          Recorded Video
                        </button>
                        <button className="px-6 py-1.5 bg-blue-600 text-white rounded-full text-sm">Join</button>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>
    )
}