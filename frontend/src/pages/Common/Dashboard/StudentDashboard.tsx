import TutorSection from "../../../components/Dashboard/TutorSection";
import InteractionsSection from "../../../components/Dashboard/InteractionsSection";
import RightSection from "../../../components/Dashboard/RightSection";

export default function Dashboard() {
  return (
    <div className="min-h-screen bg-white">

      {/* Main content */}
      <div className="relative z-10">
        {/* Main content */}
        <main className="container mx-auto px-4 py-6 grid grid-cols-1 md:grid-cols-3 gap-6">
          {/* Left sidebar */}
          <div className="md:col-span-1 space-y-6">
            {/* Tutor section */}
            <TutorSection />

            {/* Interactions section */}
            <InteractionsSection />
          </div>

          {/* Right content - Upcoming meetings */}
        <RightSection />
        </main>
      </div>
    </div>
  )
}

