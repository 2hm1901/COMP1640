import { useCallback } from 'react';
import Talk from 'talkjs';
import { Session, Inbox } from '@talkjs/react';

function Chat() {
  const syncUser = useCallback(
    () =>
      new Talk.User({
        id: 'nina',
        name: 'Nina',
        email: 'nina@example.com',
        photoUrl: 'https://talkjs.com/new-web/avatar-7.jpg',
        welcomeMessage: 'Hi!',
      }),
    []
  );

  const syncConversation = useCallback((session) => {
    // JavaScript SDK code here
    const conversation = session.getOrCreateConversation('new_conversation');

    const other = new Talk.User({
      id: 'frank',
      name: 'Frank',
      email: 'frank@example.com',
      photoUrl: 'https://talkjs.com/new-web/avatar-8.jpg',
      welcomeMessage: 'Hey, how can I help?',
    });
    conversation.setParticipant(session.me);
    conversation.setParticipant(other);

    return conversation;
  }, []);

  return (
    <Session appId="tvZvoxPA" syncUser={syncUser}>
      <Inbox
        syncConversation={syncConversation}
        style={{ width: '100%', height: '500px' }}
      ></Inbox>
    </Session>
  );
}

export default Chat;
