import { useState } from "react";
import { db } from "../firebase";
import { collection, addDoc, getDocs, query, where } from "firebase/firestore";

export default function StudyGroupForm() {
  const [groupName, setGroupName] = useState("");
  const [action, setAction] = useState("create");

  const handleSubmit = async (e) => {
    e.preventDefault();

    const groupsRef = collection(db, "studyGroups");

    if (action === "create") {
      await addDoc(groupsRef, { name: groupName });
      alert(`Group '${groupName}' created!`);
    } else {
      const q = query(groupsRef, where("name", "==", groupName));
      const snapshot = await getDocs(q);
      if (!snapshot.empty) {
        alert(`Joined group '${groupName}'!`);
      } else {
        alert("Group not found.");
      }
    }

    setGroupName("");
  };

  return (
    <div>
      <h2>{action === "create" ? "Create" : "Join"} Study Group</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Group Name"
          value={groupName}
          onChange={(e) => setGroupName(e.target.value)}
          required
        />
        <select onChange={(e) => setAction(e.target.value)} value={action}>
          <option value="create">Create</option>
          <option value="join">Join</option>
        </select>
        <button type="submit">{action === "create" ? "Create" : "Join"}</button>
      </form>
    </div>
  );
}